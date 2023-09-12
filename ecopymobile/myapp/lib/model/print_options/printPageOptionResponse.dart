import 'dart:ffi';

import 'package:json_annotation/json_annotation.dart';

part 'printPageOptionResponse.g.dart';

@JsonSerializable()
class PrintPageOptionResponse {
  int? id;
  String? name;
  bool? isActive;

  PrintPageOptionResponse() {}

  factory PrintPageOptionResponse.fromJson(Map<String, dynamic> json) =>
      _$PrintPageOptionResponseFromJson(json);

  /// Connect the generated [_$PrintPageOptionResponseToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$PrintPageOptionResponseToJson(this);
}
