import 'package:flutter/material.dart';
import 'dart:math' as math;
import 'package:numberpicker/numberpicker.dart';

class ClockPomodoro extends StatefulWidget {
  @override
  _ClockPomodoroState createState() => _ClockPomodoroState();
}

class _ClockPomodoroState extends State<ClockPomodoro>
    with TickerProviderStateMixin {
  AnimationController controller;

  String get timerString {
    Duration duration = controller.duration * controller.value;
    return '${duration.inMinutes}:${(duration.inSeconds % 60).toString().padLeft(2, '0')}';
  }

  int duration = 1;
  bool comp = false;

  void initState() {
    super.initState();
    controller = AnimationController(
      vsync: this,
      duration: Duration(seconds: duration),
    );
  }

  Future<bool> _exit() {
    return showDialog(
      context: context,
      builder: (context) => AlertDialog(
        title: Text(
            'If you go back, your progress will lose, do you want to continue?'),
        actions: <Widget>[
          FlatButton(
            child: Text('No'),
            onPressed: () => Navigator.pop(context, false),
          ),
          FlatButton(
            child: Text('Yes'),
            onPressed: () => Navigator.pop(context, true),
          )
        ],
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    return WillPopScope(
      onWillPop: _exit,
      child: Scaffold(
        body: Padding(
          padding: EdgeInsets.all(0.0),
          child: Column(
            children: <Widget>[
              Expanded(
                child: Align(
                  alignment: FractionalOffset.center,
                  child: AspectRatio(
                    aspectRatio: 1.0,
                    child: Stack(
                      children: <Widget>[
                        Positioned.fill(
                          child: AnimatedBuilder(
                            animation: controller,
                            builder: (BuildContext context, Widget child) {
                              return CustomPaint(
                                  painter: TimerPainter(
                                animation: controller,
                                backgroundColor: Colors.white,
                                color: Colors.pink,
                              ));
                            },
                          ),
                        ),
                        Align(
                          alignment: FractionalOffset.center,
                          child: Column(
                            mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                            crossAxisAlignment: CrossAxisAlignment.center,
                            children: <Widget>[
                              Text(
                                'StudyTime= $duration minutes',
                                style: TextStyle(
                                  color: Colors.black,
                                ),
                              ),
                              AnimatedBuilder(
                                animation: controller,
                                builder: (BuildContext context, Widget child) {
                                  return new Text(
                                    timerString,
                                    style: TextStyle(
                                      color: Colors.black,
                                      fontSize: 50,
                                    ),
                                  );
                                },
                              ),
                            ],
                          ),
                        ),
                      ],
                    ),
                  ),
                ),
              ),
              Container(
                margin: EdgeInsets.all(0),
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                  children: <Widget>[
                    FloatingActionButton(
                      child: AnimatedBuilder(
                        animation: controller,
                        builder: (BuildContext context, Widget child) {
                          return new Icon(controller.isAnimating
                              ? Icons.pause
                              : Icons.play_arrow);
                        },
                      ),
                      onPressed: () {
                        if (controller.isAnimating) {
                          controller.stop();
                        } else {
                          controller.reverse(
                              from:
                                  controller.value == 0 ? 1 : controller.value);
                        }
                      },
                    )
                  ],
                ),
              ),
              Container(
                child: AnimatedBuilder(
                  animation: controller,
                  builder: (BuildContext context, Widget child) {
                    return new Container(
                        child: controller.isAnimating
                            ? Text('running ${comp = true}')
                            : Row(
                                mainAxisAlignment: MainAxisAlignment.center,
                                children: <Widget>[
                                  Column(
                                    children: <Widget>[
                                      Text(
                                          'Try me to insert a \n new time to study'),
                                      Text(
                                        '$duration minutes',
                                        style: TextStyle(
                                            color: Colors.indigo, fontSize: 25),
                                      )
                                    ],
                                  ),
                                  NumberPicker.integer(
                                    initialValue: 0,
                                    minValue: 0,
                                    maxValue: 60,
                                    onChanged: (val) {
                                      setState(
                                        () {
                                          duration = val;
                                          controller = AnimationController(
                                            vsync: this,
                                            duration:
                                                Duration(minutes: duration),
                                          );
                                        },
                                      );
                                    },
                                  ),
                                ],
                              ));
                  },
                ),
              ),
              AnimatedBuilder(
                animation: controller,
                builder: (BuildContext context, Widget child) {
                  return new Container(
                      child: !controller.isAnimating && comp
                          ? AlertDialog(
                              title: Text('You did it!'),
                              actions: <FlatButton>[
                                FlatButton(
                                    onPressed: () =>
                                        Navigator.pop(context, true),
                                    child: Text('Continue'))
                              ],
                            )
                          : Text(''));
                },
              ),
            ],
          ),
        ),
      ),
    );
  }
}

class TimerPainter extends CustomPainter {
  TimerPainter({
    this.animation,
    this.backgroundColor,
    this.color,
  }) : super(repaint: animation);
  final Animation<double> animation;
  final Color backgroundColor, color;

  @override
  void paint(Canvas canvas, Size size) {
    Paint paint = Paint()
      ..color = backgroundColor
      ..strokeWidth = 5.0
      ..strokeCap = StrokeCap.round
      ..style = PaintingStyle.stroke;
    canvas.drawCircle(size.center(Offset.zero), size.width / 2.0, paint);
    paint.color = color;
    double progress = (1 - animation.value) * 2 * math.pi;
    canvas.drawArc(Offset.zero & size, math.pi * 1.5, -progress, false, paint);
  }

  @override
  bool shouldRepaint(TimerPainter old) {
    return animation.value != old.animation.value ||
        color != old.color ||
        backgroundColor != old.backgroundColor;
  }
}
