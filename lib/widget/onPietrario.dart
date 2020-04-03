import 'package:flutter/material.dart';
import 'IntPomodoro.dart';

class PrincPietrario extends StatelessWidget {
  void _startPomodoro(BuildContext ctx) {
    showModalBottomSheet(
        context: ctx,
        builder: (_) {
          return GestureDetector(
            child: IntPomodoro(),
            onTap: () {},
            behavior: HitTestBehavior.opaque,
          );
        });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Column(
        mainAxisAlignment: MainAxisAlignment.end,
        children: <Widget>[
          FloatingActionButton(
            child: Icon(Icons.calendar_today),
            onPressed: () {
              _startPomodoro(context);
            },
          ),
          Row(
            children: <Widget>[
              Container(
                color: Colors.indigo,
                padding: EdgeInsets.only(right: 139),
                child: IconButton(
                  iconSize: 50,
                  icon: Icon(Icons.wb_sunny),
                  onPressed: () {
                    // Sun function displayed
                  },
                ),
              ),
              Container(
                color: Colors.indigo,
                padding: EdgeInsets.only(left: 140),
                child: IconButton(
                  iconSize: 50,
                  icon: Icon(Icons.build),
                  onPressed: () {
                    // Pietrario's config
                  },
                ),
              ),
            ],
          )
        ],
      ),
    );
  }
}
