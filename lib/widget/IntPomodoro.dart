import 'package:flutter/material.dart';
import 'package:flutter_duration_picker/flutter_duration_picker.dart';
import 'dart:async';

class IntPomodoro extends StatefulWidget {
  @override
  _IntPomodoroState createState() => _IntPomodoroState();
}

class _IntPomodoroState extends State<IntPomodoro> {
  Duration _duration = Duration(hours: 0, minutes: 0);
  bool started = true;
  bool finished = false;
  int timeForTimer = 0;
  Duration partial = Duration();
  String timetoDisplay = 'not created';
  void start() {
    setState(() {
      started = false;
      finished = true;
    });
    timeForTimer = _duration.inSeconds;
    Timer.periodic(Duration(seconds: 1), (Timer t) {
      setState(() {
        if (timeForTimer < 1) {
          t.cancel();
          started = true;
        } else {
          if (timeForTimer < 60) {
            timetoDisplay = timeForTimer.toString();
            _duration = Duration(seconds: timeForTimer);
            timeForTimer--;
          } else {
            if (timeForTimer < 3600) {
              int m = timeForTimer ~/ 60;
              int s = timeForTimer - (60 * m);
              timetoDisplay = m.toString() + ' : ' + s.toString();
              _duration = Duration(minutes: m, seconds: s);
              timeForTimer--;
            } else {
              int h = timeForTimer ~/ 3600;
              int t = timeForTimer - (3600 * h);
              int m = t ~/ 60;
              int s = t - (60 * m);
              timetoDisplay =
                  h.toString() + ' : ' + m.toString() + ' : ' + s.toString();
              _duration = Duration(hours: h, minutes: m, seconds: s);
              timeForTimer--;
            }
          }
        }
      });
    });
  }

  void stop() {}
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: Column(children: <Widget>[
      Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: <Widget>[
          DurationPicker(
            duration: _duration,
            onChange: (val) {
              this.setState(() => _duration = val);
            },
            snapToMins: 5.0,
          ),
          FlatButton(
            onPressed: started ? start : null,
            child: Text('Push'),
          ),
        ],
      ),
      Row(
        children: <Widget>[
          Container(
            child: Text(
              'Work time: $timetoDisplay',
              style: TextStyle(
                fontWeight: FontWeight.bold,
                fontSize: 35,
              ),
            ),
          ),
        ],
      )
    ]));
  }
}
