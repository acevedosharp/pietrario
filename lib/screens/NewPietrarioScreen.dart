import 'package:flutter/material.dart';
import 'package:pr/model/Pietrario.dart';
import 'package:pr/model/PietrarioProvider.dart';
import 'package:provider/provider.dart';

class NewPietrarioScreen extends StatefulWidget {
  static final route = '/new-pietrario';

  @override
  _NewPietrarioScreenState createState() => _NewPietrarioScreenState();
}

class _NewPietrarioScreenState extends State<NewPietrarioScreen> {
  final _form = GlobalKey<FormState>();

  var _pietrario = Pietrario(nombre: '');

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Crear Pietrario'),
      ),
      body: Padding(
        padding: const EdgeInsets.all(16),
        child: Form(
          key: _form,
          child: SingleChildScrollView(
            child: Column(
              children: <Widget>[
                TextFormField(
                  decoration: InputDecoration(labelText: 'Nombre'),
                  textInputAction: TextInputAction.done,
                  onFieldSubmitted: (_) {
                    _saveForm();
                  },
                  onSaved: (value) {
                    _pietrario = Pietrario(nombre: value);
                  },
                  validator: (value) {
                    if (value.isEmpty) return 'Campo requerido.';
                    return null;
                  },
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }

  void _saveForm() {
    if (_form.currentState.validate()) {
      _form.currentState.save();
      Provider.of<PietrarioProvider>(context, listen: false).addPietrario(_pietrario);
      Navigator.of(context).pop;
    }
  }
}
