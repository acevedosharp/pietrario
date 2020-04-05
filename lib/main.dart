import 'package:flutter/material.dart';
import 'package:pr/widget/piet.dart';

void main() => runApp(MyApp());

class MyApp extends StatefulWidget {
  @override
  _MyAppState createState() => _MyAppState();
}

class _MyAppState extends State<MyApp> {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Pietrario',
      theme: ThemeData(
        primarySwatch: Colors.indigo,
      ),
      home: Principal(),
    );
  }
}

class Principal extends StatefulWidget {
  @override
  _PrincipalState createState() => _PrincipalState();
}

class _PrincipalState extends State<Principal> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Menú principal'),
      ),
      body: Column(
        children: <Widget>[
          Container(
            child: Text(
              'Pietrario´s List',
              style: TextStyle(
                fontSize: 50,
              ),
            ),
          ),
          ListaPietrario(),
        ],
      ),
    );
  }
}
