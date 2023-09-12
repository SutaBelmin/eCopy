import 'dart:ffi';

import 'package:json_annotation/json_annotation.dart';

part 'orientationResponse.g.dart';

@JsonSerializable()
class OrientationResponse {
  int? id;
  String? name;
  bool? isActive;

  OrientationResponse() {}

  factory OrientationResponse.fromJson(Map<String, dynamic> json) =>
      _$OrientationResponseFromJson(json);

  /// Connect the generated [_$OrientationResponseToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$OrientationResponseToJson(this);
}
