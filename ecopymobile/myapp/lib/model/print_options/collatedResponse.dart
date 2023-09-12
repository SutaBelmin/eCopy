import 'dart:ffi';

import 'package:json_annotation/json_annotation.dart';

part 'collatedResponse.g.dart';

@JsonSerializable()
class CollatedResponse {
  int? id;
  String? name;
  bool? isActive;

  CollatedResponse() {}

  factory CollatedResponse.fromJson(Map<String, dynamic> json) =>
      _$CollatedResponseFromJson(json);

  /// Connect the generated [_$CollatedResponseToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$CollatedResponseToJson(this);
}
