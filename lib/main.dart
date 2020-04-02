import 'package:flutter/material.dart';

void main() => runApp(MyApp());

class MyApp extends StatelessWidget {
  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {


    return MaterialApp(
      theme: ThemeData(
        primarySwatch: Colors.black
      ),
      home: Scaffold(
        appBar: AppBar(
          title: Text('Pietrario'),
          backgroundColor: Colors.black38,
        ),
      body: Container(
      decoration: new BoxDecoration(
        gradient: LinearGradient(
        colors: [Colors.black26,Colors.white],
        stops: [0.5,0.5],
        begin: FractionalOffset.topCenter,
        end: FractionalOffset.bottomCenter
      ),
    ),
    ),
      bottomNavigationBar: BottomAppBar(
        child:
        Center(child:
        FloatingActionButton(child: Text("Hola"),
          onPressed: null,
        )
        )
        ,
      ),
      )
    );
  }
}

