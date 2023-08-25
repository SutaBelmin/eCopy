import 'dart:ffi';

import 'package:json_annotation/json_annotation.dart';

part 'updateRequest.g.dart';

@JsonSerializable()
class UpdateRequest {
  int? status;
  int? options;
  int? side;
  int? orientation;
  int? letter;
  int? pages;
  int? collate;

  UpdateRequest() {}

  factory UpdateRequest.fromJson(Map<String, dynamic> json) =>
      _$UpdateRequestFromJson(json);

  /// Connect the generated [_$UpdateRequestToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$UpdateRequestToJson(this);
}
