import 'dart:ffi';

import 'package:json_annotation/json_annotation.dart';

part 'personRequest.g.dart';

@JsonSerializable()
class PersonRequest {
  String? firstName;
  String? lastName;
  String? middleName;
  int? gender;
  int? cityId;
  String? address;
  DateTime? birthDate;

  PersonRequest() {}

  factory PersonRequest.fromJson(Map<String, dynamic> json) =>
      _$PersonRequestFromJson(json);

  /// Connect the generated [_$PersonRequestToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$PersonRequestToJson(this);
}
