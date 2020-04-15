import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_icons/flutter_icons.dart';
import 'package:pr/widget/clockPomodoro.dart';

//class needs to extend StatefulWidget since we need to make changes to the bottom app bar according to the user clicks
class Home extends StatefulWidget {
  static final route = '/evaluation';

  @override
  State<StatefulWidget> createState() {
    return HomeState();
  }
}

class HomeState extends State<Home> {
  bool clickedCentreFAB = false; //boolean used to handle container animation which expands from the FAB
  int selectedIndex = 0; //to handle which item is currently selected in the bottom app bar
  String text = "Evaluation";

  //call this method on click of each bottom app bar item to update the screen
  void updateTabSelection(int index, String buttonText) {
    setState(() {
      selectedIndex = index;
      text = buttonText;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Stack(
        children: <Widget>[
          //this is the code for the widget container that comes from behind the floating action button (FAB)
          Padding(
            padding: EdgeInsets.all(0),
            child: Stack(
              children: <Widget>[
                Image.asset(
                  'assets/images/lowpoly_landscape.png',
                  fit: BoxFit.cover,
                  width: double.infinity,
                  height: double.infinity,
                ),
                Padding(
                  padding: EdgeInsets.symmetric(vertical: 24, horizontal: 16),
                  child: Align(
                    alignment: FractionalOffset.topLeft,
                    child: Row(
                      children: <Widget>[
                        Stack(
                          alignment: FractionalOffset.center,
                          children: <Widget>[

                            Container(
                              child: IconButton(
                                icon: Icon(
                                  FontAwesome.tint,
                                  color: Colors.white,
                                ),
                                onPressed: () {},
                              ),
                              decoration: BoxDecoration(color: const Color(0xff242E42), shape: BoxShape.circle),
                            ),
                            RotationTransition(
                              turns: AlwaysStoppedAnimation(210 / 360),
                              child: SizedBox(
                                child: CircularProgressIndicator(
                                  backgroundColor: const Color(0xff3E4E6C),
                                  valueColor: AlwaysStoppedAnimation<Color>(const Color(0xff03DAC4)),
                                  value: 0.5,
                                  strokeWidth: 10,
                                ),
                                height: 50,
                                width: 50,
                              ),
                            ),
                          ],
                        ),
                        SizedBox(width: 20),
                        Stack(
                          alignment: FractionalOffset.center,
                          children: <Widget>[
                            Container(
                              child: IconButton(
                                icon: Icon(
                                  Icons.wb_sunny,
                                  color: Colors.white,
                                ),
                                onPressed: () {},
                              ),
                              decoration: BoxDecoration(color: const Color(0xff242E42), shape: BoxShape.circle),
                            ),
                            RotationTransition(
                              turns: AlwaysStoppedAnimation(210 / 360),
                              child: SizedBox(
                                child: CircularProgressIndicator(
                                  backgroundColor: const Color(0xff3E4E6C),
                                  valueColor: AlwaysStoppedAnimation<Color>(const Color(0xff03DAC4)),
                                  value: 0.5,
                                  strokeWidth: 10,
                                ),
                                height: 50,
                                width: 50,
                              ),
                            ),
                          ],
                        ),
                      ],
                    ),
                  ),
                ),
              ],
            ),
          )
        ],
      ),
      floatingActionButtonLocation: FloatingActionButtonLocation.centerDocked, //specify the location of the FAB
      floatingActionButton: FloatingActionButton(
        heroTag: "hero1",
        onPressed: () {
          Navigator.of(context).pushNamed(ClockPomodoro.route);
//          setState(() {
//            clickedCentreFAB = !clickedCentreFAB; //to update the animated container
//          });
        },
        tooltip: "Pomodoro",
        child: Container(
          child: Icon(
            Icons.access_time,
            color: Colors.black,
            size: 32,
          ),
        ),
        elevation: 4.0,
        backgroundColor: const Color(0xff03DAC4),
      ),
      bottomNavigationBar: BottomAppBar(
        child: Container(
          height: 64,
          margin: EdgeInsets.only(left: 12.0, right: 12.0),
          child: Row(
            mainAxisSize: MainAxisSize.max,
            mainAxisAlignment: MainAxisAlignment.spaceAround,
            children: <Widget>[
              Column(
                children: <Widget>[
                  IconButton(
                    onPressed: () {
                      updateTabSelection(1, "Outgoing");
                    },
                    iconSize: 32.0,
                    icon: Icon(
                      Icons.wb_sunny,
                      color: Colors.white,
                    ),
                  ),
                  if (selectedIndex == 1)
                    Container(
                      width: 4,
                      height: 4,
                      decoration: BoxDecoration(color: Colors.white, shape: BoxShape.circle),
                    )
                ],
              ),
              SizedBox(
                width: 32,
              ),
              Column(
                children: <Widget>[
                  IconButton(
                    onPressed: () {
                      updateTabSelection(2, "Incoming");
                    },
                    iconSize: 32.0,
                    icon: Icon(
                      FontAwesome.leaf,
                      color: Colors.white,
                    ),
                  ),
                  if (selectedIndex == 2)
                    Container(
                      width: 4,
                      height: 4,
                      decoration: BoxDecoration(color: Colors.white, shape: BoxShape.circle),
                    )
                ],
              ),
            ],
          ),
        ),
        //to add a space between the FAB and BottomAppBar
        shape: CircularNotchedRectangle(),
        //color of the BottomAppBar
        color: const Color(0xff6200EE),
      ),
    );
  }
}
