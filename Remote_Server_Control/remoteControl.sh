./ffmpeg_stream/capture_and_stream_from_usb &
cd TCP_Server 
java Server1 | sudo ../hid_keyboard/hid_keyboard /dev/hidg0 keyboard
