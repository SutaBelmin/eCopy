import 'dart:ffi';

import 'package:json_annotation/json_annotation.dart';

part 'passRequest.g.dart';

@JsonSerializable()
class PassRequest {
  String? oldPass;
  String? newPass;
  String? confPass;

  PassRequest() {}

  factory PassRequest.fromJson(Map<String, dynamic> json) =>
      _$PassRequestFromJson(json);

  /// Connect the generated [_$PassRequestToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$PassRequestToJson(this);
}
