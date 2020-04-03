import 'package:flutter/material.dart';
import './onPietrario.dart';

class ListaPietrario extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Row(
      children: <Widget>[
        Container(
          width: 100,
          height: 100,
          decoration: BoxDecoration(
            image: DecorationImage(
              image: AssetImage('assets/images/sinFoto.png'),
            ),
          ),
          child: FlatButton(
            child: null,
            onPressed: () {
              Navigator.push(
                context,
                MaterialPageRoute(builder: (context) => PrincPietrario()),
              );
            },
          ),
        ),
      ],
    );
  }
}
