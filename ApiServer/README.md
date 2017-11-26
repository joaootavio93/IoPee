# IoPee API

## Get all registered devices
http://[hostname]/iopee/api/v1.0/devices
```javascript
{
  "devices": [
    {
      "Humidity": "975", 
      "MacId": "2C:3A:E8:06:9A:5D", 
      "Temperature": "none", 
      "id": 1, 
      "timestamp": "26-11-2017 00:49:06"
    }
  ]
}
```

## Get data for specific device
http://[hostname]/iopee/api/v1.0/devices/<int:device_id>

