import 'dart:ffi';

import 'package:json_annotation/json_annotation.dart';

part 'letterResponse.g.dart';

@JsonSerializable()
class LetterResponse {
  int? id;
  String? name;
  bool? isActive;

  LetterResponse() {}

  factory LetterResponse.fromJson(Map<String, dynamic> json) =>
      _$LetterResponseFromJson(json);

  /// Connect the generated [_$LetterResponseToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$LetterResponseToJson(this);
}
