# IoPee API

| HTTP METHOD | POST            | GET       |
| ----------- | --------------- | --------- |
| /iopee/api/v1.0/devices       | Register new device | List all registered devices |
| /iopee/api/v1.0/devices/<int:device_id>       | Update device humidity | Get device info |
| /iopee/api/v1.0/devices/newdiaper/<int:device_id>       | Register that diaper was replaced by a new one | - |

* ```CurrentTime```: time at request from server
* ```Humidity```: value read from sensor
* ```LastChange```: last time that the diaper was replaced
* ```LastUpdate```: last time that humidity value was updated (rate: 1 min)
* ```MacId```: device mac address


## Get all registered devices
http://[hostname]/iopee/api/v1.0/devices
```javascript
{
  "devices": [
    {
      "CurrentTime": "26-11-2017 12:02:51",
      "Humidity": "974",
      "LastChange": "none",
      "LastUpdate": "26-11-2017 12:02:48",
      "MacId": "2C:3A:E8:06:9A:5D",
      "Temperature": "none",
      "id": 1
    }
  ]
}
```

## Get data for specific device
http://[hostname]/iopee/api/v1.0/devices/<int:device_id>
```javascript
{
  "device": {
    "CurrentTime": "26-11-2017 12:04:42",
    "Humidity": "975",
    "LastChange": "none",
    "LastUpdate": "26-11-2017 12:03:44",
    "MacId": "2C:3A:E8:06:9A:5D",
    "Temperature": "none",
    "id": 1
  }
}
```
