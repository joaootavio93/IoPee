from flask import Flask, url_for, request, jsonify, abort, make_response
import time
import datetime

app = Flask(__name__)

devices = []

@app.route('/')
def api_root():
    return 'Server running'

@app.route('/iopee/api/v1.0/devices', methods=['GET'])
def get_devices():
    return jsonify({'devices': devices})

@app.route('/iopee/api/v1.0/devices/<int:device_id>', methods=['GET'])
def get_device(device_id):
    device = [device for device in devices if device['id'] == device_id]
    if len(device) == 0:
        abort(404)
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
        'timestamp': datetime.datetime.fromtimestamp(ts).strftime('%d-%m-%Y %H:%M:%S')
    }
    devices.append(device)
    return jsonify({'device': device}), 201


@app.route('/iopee/api/v1.0/devices/<int:device_id>', methods = ['POST'])
def api_message(device_id):
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
        device[0]["timestamp"] = datetime.datetime.fromtimestamp(ts).strftime('%d-%m-%Y %H:%M:%S')
        return "Sent " + request.data.decode("utf-8") + ",'date':" + datetime.datetime.fromtimestamp(ts).strftime('%d-%m-%Y')+",'time':"+datetime.datetime.fromtimestamp(ts).strftime('%H:%M:%S')

    else:
        return "415 Unsupported Media Type"

if __name__ == '__main__':
    app.run(host='0.0.0.0')
