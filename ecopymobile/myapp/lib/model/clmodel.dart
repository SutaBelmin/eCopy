import 'dart:ffi';

import 'package:json_annotation/json_annotation.dart';

part 'clmodel.g.dart';

@JsonSerializable()
class Clmodel {
  bool? username;
  bool? email;

  Clmodel() {}

  factory Clmodel.fromJson(Map<String, dynamic> json) =>
      _$ClmodelFromJson(json);

  /// Connect the generated [_$ClmodelToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$ClmodelToJson(this);
}
