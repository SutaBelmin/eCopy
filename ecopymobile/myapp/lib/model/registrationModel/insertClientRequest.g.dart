// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'insertClientRequest.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

InsertClientRequest _$InsertClientRequestFromJson(Map<String, dynamic> json) =>
    InsertClientRequest()
      ..firstName = json['firstName'] as String?
      ..lastName = json['lastName'] as String?
      ..middleName = json['middleName'] as String?
      ..gender = json['gender'] as String?
      ..cityId = json['cityId'] as int?
      ..address = json['address'] as String?
      ..birthDate = json['birthDate'] == null
          ? null
          : DateTime.parse(json['birthDate'] as String)
      ..email = json['email'] as String?
      ..username = json['username'] as String?
      ..phoneNumber = json['phoneNumber'] as String?
      ..role = json['role'] as String?
      ..password = json['password'] as String?
      ..passwordConfirm = json['passwordConfirm'] as String?
      ..active = json['active'] as bool?;

Map<String, dynamic> _$InsertClientRequestToJson(
        InsertClientRequest instance) =>
    <String, dynamic>{
      'firstName': instance.firstName,
      'lastName': instance.lastName,
      'middleName': instance.middleName,
      'gender': instance.gender,
      'cityId': instance.cityId,
      'address': instance.address,
      'birthDate': instance.birthDate?.toIso8601String(),
      'email': instance.email,
      'username': instance.username,
      'phoneNumber': instance.phoneNumber,
      'role': instance.role,
      'password': instance.password,
      'passwordConfirm': instance.passwordConfirm,
      'active': instance.active,
    };
