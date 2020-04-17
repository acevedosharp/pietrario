import 'dart:math';

import 'package:flutter/material.dart';
import 'package:pr/model/Pietrario.dart';
import 'package:pr/screens/onPietrario.dart';

class SinglePietrarioDisplay extends StatelessWidget {
  final Pietrario pietrario;

  const SinglePietrarioDisplay(this.pietrario);

  @override
  Widget build(BuildContext context) {
    return ClipRRect(
      borderRadius: BorderRadius.circular(12),
      child: GridTile(
        child: GestureDetector(
          onTap: () {
            Navigator.of(context).pushNamed(PrincPietrario.route);
          },
          child: Image.asset(
            'assets/images/sinFoto.png',
            fit: BoxFit.cover,
            height: 110,
            width: 110,
          ),
        ),
        footer: GridTileBar(
          backgroundColor: Colors.black54,
          title: Text(
            pietrario.nombre,
            textAlign: TextAlign.center,
          ),
          trailing: IconButton(
            icon: Icon(Icons.more_vert),
            onPressed: () {},
            color: Colors.white,
          ),
        ),
      ),
    );

  }
}
