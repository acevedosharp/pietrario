import 'package:flutter/material.dart';

class PrincPietrario extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Column(
        mainAxisAlignment: MainAxisAlignment.end,
        children: <Widget>[
          IconButton(
            iconSize: 50,
            icon: Icon(Icons.date_range),
            onPressed: () {
              // Pomodoro settings
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
