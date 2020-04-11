import 'package:flutter/material.dart';
import 'package:pr/widget/PietrarioList.dart';

class HomeScreen extends StatelessWidget {
  static final route = '/';

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Lista de Pietrarios'),
      ),
      body: Container(
        margin: EdgeInsets.all(16),
        width: double.infinity,
        height: double.infinity,
        child: PietrarioList(),
      ),
    );
  }
}
