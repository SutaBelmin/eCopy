import 'dart:ffi';

import 'package:json_annotation/json_annotation.dart';

part 'sideResponse.g.dart';

@JsonSerializable()
class SideResponse {
  int? id;
  String? name;
  bool? isActive;

  SideResponse() {}

  factory SideResponse.fromJson(Map<String, dynamic> json) =>
      _$SideResponseFromJson(json);

  /// Connect the generated [_$SideResponseToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$SideResponseToJson(this);
}
