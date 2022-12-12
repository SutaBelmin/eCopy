//import 'package:json_serializable/builder.dart';
import 'dart:ffi';

import 'package:json_annotation/json_annotation.dart';

part 'request.g.dart';

@JsonSerializable()
class Request {
  int? ID;
  String? Status;
  String? Side;
  String? Options;
  String? Orientation;
  String? Letter;
  String? Collate;

  Request() {}

  factory Request.fromJson(Map<String, dynamic> json) =>
      _$RequestFromJson(json);

  /// Connect the generated [_$RequestToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$RequestToJson(this);
}
