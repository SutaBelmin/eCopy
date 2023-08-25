import 'dart:ffi';

import 'package:json_annotation/json_annotation.dart';

part 'clientRequestUpdate.g.dart';

@JsonSerializable()
class ClientRequestUpdate {
  bool? active;
  String? firstName;
  String? lastName;
  String? middleName;
  int? gender;
  int? cityId;
  String? address;
  DateTime? birthDate;
  String? email;
  String? username;
  String? phoneNumber;

  ClientRequestUpdate() {}

  factory ClientRequestUpdate.fromJson(Map<String, dynamic> json) =>
      _$ClientRequestUpdateFromJson(json);

  /// Connect the generated [_$ClientRequestUpdateToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$ClientRequestUpdateToJson(this);
}
