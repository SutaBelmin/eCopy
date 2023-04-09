import 'dart:ffi';

import 'package:json_annotation/json_annotation.dart';

part 'printRequest.g.dart';

@JsonSerializable()
class PrintRequest {
  int? status;
  int? side;
  int? options;
  int? orientation;
  int? letter;
  int? collate;
  int? pagePerSheet;

  PrintRequest() {}

  factory PrintRequest.fromJson(Map<String, dynamic> json) =>
      _$PrintRequestFromJson(json);

  /// Connect the generated [_$PrintRequestToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$PrintRequestToJson(this);
}
