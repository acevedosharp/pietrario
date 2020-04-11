import 'package:flutter/material.dart';
import 'package:pr/model/PietrarioProvider.dart';
import 'package:pr/screens/HomeScreen.dart';
import 'package:pr/screens/NewPietrarioScreen.dart';
import 'package:pr/screens/onPietrario.dart';
import 'package:pr/widget/piet.dart';
import 'package:provider/provider.dart';

void main() => runApp(MyApp());

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MultiProvider(
      providers: [
        ChangeNotifierProvider.value(value: PietrarioProvider())
      ],
      child: MaterialApp(
        debugShowCheckedModeBanner: false,
        title: 'Pietrario',
        theme: ThemeData(
          primaryColor: Colors.indigo,
          accentColor: Colors.indigoAccent
        ),
        // There is no 'home', that's because in the routes map, the entry with the '/' String is the home. (in this case the HomeScreen)
        routes: {
          HomeScreen.route: (ctx) => HomeScreen(),
          NewPietrarioScreen.route: (ctx) => NewPietrarioScreen(),
          PrincPietrario.route: (ctx) => PrincPietrario(),
        },
      ),
    );
  }
}
