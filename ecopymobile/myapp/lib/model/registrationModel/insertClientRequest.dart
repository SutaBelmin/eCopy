import 'dart:ffi';

import 'package:json_annotation/json_annotation.dart';

part 'insertClientRequest.g.dart';

@JsonSerializable()
class InsertClientRequest {
  String? firstName;
  String? lastName;
  String? middleName;
  String? gender;
  int? cityId;
  String? address;
  DateTime? birthDate;
  String? email;
  String? username;
  String? phoneNumber;
  String? role;
  String? password;
  String? passwordConfirm;
  bool? active;

  InsertClientRequest();

  factory InsertClientRequest.fromJson(Map<String, dynamic> json) =>
      _$InsertClientRequestFromJson(json);

  /// Connect the generated [_$InsertClientRequestToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$InsertClientRequestToJson(this);
}
