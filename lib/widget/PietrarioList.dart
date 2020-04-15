import 'package:flutter/material.dart';
import 'package:pr/model/PietrarioProvider.dart';
import 'package:pr/screens/NewPietrarioScreen.dart';
import 'package:pr/widget/SinglePietrarioDisplay.dart';
import 'package:provider/provider.dart';

import '../screens/EvaluationScreen.dart';

class PietrarioList extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    final PietrarioProvider pietrarioProvider = Provider.of<PietrarioProvider>(context);
    final pietrariosSnapshot = pietrarioProvider.pietrarios;

    return pietrariosSnapshot.isEmpty
        ? Column(
            children: <Widget>[
              Text('Aún no tienes ningún pietrario.'),
              SizedBox(height: 5),
              RaisedButton(
                child: Row(
                  mainAxisSize: MainAxisSize.min,
                  children: <Widget>[
                    Text('Crear'),
                    SizedBox(width: 4),
                    Icon(Icons.add),
                  ],
                ),
                onPressed: () {
//                  Navigator.of(context).pushNamed(NewPietrarioScreen.route);
                  Navigator.of(context).pushNamed(Home.route);
                },
              )
            ],
          )
        : GridView.builder(
            padding: const EdgeInsets.all(10),
            itemCount: pietrariosSnapshot.length,
            itemBuilder: (ctx, i) {
              return SinglePietrarioDisplay(pietrariosSnapshot[i]);
            },
            gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
              crossAxisCount: 1,
              childAspectRatio: 1.25,
            ),
          );
  }
}
