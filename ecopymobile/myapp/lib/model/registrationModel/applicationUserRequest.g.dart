// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'applicationUserRequest.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

ApplicationUserRequest _$ApplicationUserRequestFromJson(
        Map<String, dynamic> json) =>
    ApplicationUserRequest()
      ..email = json['email'] as String?
      ..username = json['username'] as String?
      ..phoneNumber = json['phoneNumber'] as String?
      ..role = json['role'] as int?
      ..password = json['password'] as String?
      ..passwordConfirm = json['passwordConfirm'] as String?;

Map<String, dynamic> _$ApplicationUserRequestToJson(
        ApplicationUserRequest instance) =>
    <String, dynamic>{
      'email': instance.email,
      'username': instance.username,
      'phoneNumber': instance.phoneNumber,
      'role': instance.role,
      'password': instance.password,
      'passwordConfirm': instance.passwordConfirm,
    };
