import 'package:flutter/material.dart';
import 'package:flutter_duration_picker/flutter_duration_picker.dart';

class IntPomodoro extends StatefulWidget {

  @override
  _IntPomodoroState createState() => _IntPomodoroState();
}

class _IntPomodoroState extends State<IntPomodoro> {
  Duration _duration = Duration(hours: 0, minutes: 0);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: Container(
          padding: EdgeInsets.only(left:90),
          child: Column(
      mainAxisAlignment: MainAxisAlignment.center,
      
      children: <Widget>[
           DurationPicker(
                duration: _duration,
                onChange: (val) {
                  this.setState(() => _duration = val);
                },
                snapToMins: 5.0,
              ),
              FlatButton(onPressed: () {
                print(_duration);
              },
               child: Text('Push'))
      ],
    ),
        ));
  }
}
