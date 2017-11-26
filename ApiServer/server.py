from flask import Flask, request, jsonify, abort, make_response
import time
import datetime

app = Flask(__name__)

devices = []

@app.route('/')
def api_root():
    return 'Server running'

@app.route('/iopee/api/v1.0/devices', methods=['GET'])
def get_devices():
    devices_with_current_time = []
    ts = time.time()
    current_time = datetime.datetime.fromtimestamp(ts).strftime('%d-%m-%Y %H:%M:%S')
    for device in devices:
        device["CurrentTime"] = current_time
        devices_with_current_time.append(device)
    return jsonify({'devices': devices_with_current_time})

@app.route('/iopee/api/v1.0/devices/<int:device_id>', methods=['GET'])
def get_device(device_id):
    device = [device for device in devices if device['id'] == device_id]
    ts = time.time()
    current_time = datetime.datetime.fromtimestamp(ts).strftime('%d-%m-%Y %H:%M:%S')
    if len(device) == 0:
        abort(404)
    device[0]["CurrentTime"] = current_time
    return jsonify({'device': device[0]})

@app.errorhandler(404)
def not_found(error):
    return make_response(jsonify({'error': 'Not found'}), 404)

@app.route('/iopee/api/v1.0/devices', methods=['POST'])
def create_device():
    if not request.headers['Content-Type'] == 'text/plain':
        abort(400)
    ts = time.time()
    device_id = request.data.decode("utf-8").split(",")[0]
    mac = request.data.decode("utf-8").split(",")[1]
    device = {
        'id': int(device_id),
        'MacId': mac,
        'Humidity': "none",
        'Temperature': "none",
        'LastUpdate': datetime.datetime.fromtimestamp(ts).strftime('%d-%m-%Y %H:%M:%S'),
        'LastChange': "none"
    }
    devices.append(device)
    return jsonify({'device': device}), 201


@app.route('/iopee/api/v1.0/devices/<int:device_id>', methods = ['POST'])
def api_update(device_id):
    if request.headers['Content-Type'] == 'text/plain':
        ts = time.time()
        text_file =  open("data.txt", "a")
        text_file.write(request.data.decode("utf-8") +","+datetime.datetime.fromtimestamp(ts).strftime('%d-%m-%Y %H:%M:%S')+","+str(device_id)+"\n")
        text_file.close()
        device = [device for device in devices if device['id'] == device_id]
        print(devices,device_id)
        if len(device) == 0:
            abort(404)
        device[0]["Humidity"] = request.data.decode("utf-8").split(",")[0]
        device[0]["LastUpdate"] = datetime.datetime.fromtimestamp(ts).strftime('%d-%m-%Y %H:%M:%S')
        return "Sent " + request.data.decode("utf-8") + ",'date':" + datetime.datetime.fromtimestamp(ts).strftime('%d-%m-%Y')+",'time':"+datetime.datetime.fromtimestamp(ts).strftime('%H:%M:%S')

    else:
        return "415 Unsupported Media Type"

@app.route('/iopee/api/v1.0/devices/newdiaper/<int:device_id>', methods = ['POST'])
def api_newdiaper(device_id):
    if request.headers['Content-Type'] == 'text/plain':
        ts = time.time()
        current_time = datetime.datetime.fromtimestamp(ts).strftime('%d-%m-%Y %H:%M:%S')
        text_file =  open("data.txt", "a")
        text_file.write("diaper changed,"+request.data.decode("utf-8") +","+current_time+","+str(device_id)+"\n")
        text_file.close()
        device = [device for device in devices if device['id'] == device_id]
        print(devices,device_id)
        if len(device) == 0:
            abort(404)
        device[0]["Humidity"] = request.data.decode("utf-8").split(",")[0]
        device[0]["LastUpdate"] = current_time
        device[0]["LastChange"] = current_time
        return "Sent " + request.data.decode("utf-8") + ",'date':" + datetime.datetime.fromtimestamp(ts).strftime('%d-%m-%Y')+",'time':"+datetime.datetime.fromtimestamp(ts).strftime('%H:%M:%S')

    else:
        return "415 Unsupported Media Type"

if __name__ == '__main__':
    app.run(host='0.0.0.0')
