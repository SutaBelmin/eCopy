import 'dart:ffi';
import 'package:json_annotation/json_annotation.dart';

part 'applicationUserResponse.g.dart';

@JsonSerializable()
class ApplicationUserResponse {
  int? id;
  String? email;
  String? username;
  String? phoneNumber;
  //DateTime? lockoutEnd;
  bool? phoneNumberConfirmed;
  bool? emailConfirmed;
  bool? changePassword;
  bool? twoFactorEnabled;
  bool? active;

  ApplicationUserResponse() {}

  factory ApplicationUserResponse.fromJson(Map<String, dynamic> json) =>
      _$ApplicationUserResponseFromJson(json);

  /// Connect the generated [_$ApplicationUserResponseToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$ApplicationUserResponseToJson(this);
}
