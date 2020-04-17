import 'package:flutter/foundation.dart';
import 'package:pr/model/Pietrario.dart';

class PietrarioProvider with ChangeNotifier {
  List<Pietrario> _pietrarios = [];

  // Spread syntax here returns a copy of the List, making it imposible to modify it directly, as it should be done via the method provided below.
  List<Pietrario> get pietrarios => [..._pietrarios];

  void addPietrario(Pietrario pietrario) {
    _pietrarios.add(pietrario);
    notifyListeners();
  }
}