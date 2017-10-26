# CANLogger
CAN bus logger and analyser tool

Features:

- realtime data processing from CAN-USB devices (Arduino + MCP2151 )
- saving received data to log files for further processing
- playback log files
- separate messages by sender id, assigning human readable description to senders
- global filter data mask
- separate filter data mask for each sender
- detecting total message count, unique messages, new messages after making snapshot per each sender
- message investigating with data comparer
- holding sender descriptions between sessions

![Main window](https://github.com/olegel/CANLogger/raw/master/MainWindow.jpg)

![Investigation](https://github.com/olegel/CANLogger/raw/master/Investigation.jpg)

Known issues:
- CAN bus baud-rate setting is ignored yet

