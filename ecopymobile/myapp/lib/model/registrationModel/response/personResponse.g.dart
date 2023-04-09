// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'personResponse.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

PersonResponse _$PersonResponseFromJson(Map<String, dynamic> json) =>
    PersonResponse()
      ..id = json['id'] as int?
      ..firstName = json['firstName'] as String?
      ..lastName = json['lastName'] as String?
      ..middleName = json['middleName'] as String?
      ..gender = json['gender'] as String?
      ..cityId = json['cityId'] as int?
      ..city = json['city'] == null
          ? null
          : CityResponse.fromJson(json['city'] as Map<String, dynamic>)
      ..address = json['address'] as String?
      ..birthDate = json['birthDate'] == null
          ? null
          : DateTime.parse(json['birthDate'] as String);

Map<String, dynamic> _$PersonResponseToJson(PersonResponse instance) =>
    <String, dynamic>{
      'id': instance.id,
      'firstName': instance.firstName,
      'lastName': instance.lastName,
      'middleName': instance.middleName,
      'gender': instance.gender,
      'cityId': instance.cityId,
      'city': instance.city,
      'address': instance.address,
      'birthDate': instance.birthDate?.toIso8601String(),
    };
