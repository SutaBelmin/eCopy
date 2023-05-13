// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'cityResponse.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

CityResponse _$CityResponseFromJson(Map<String, dynamic> json) => CityResponse()
  ..id = json['id'] as int?
  ..name = json['name'] as String?
  ..shortName = json['shortName'] as String?
  ..postalCode = json['postalCode'] as int?
  ..country = json['country'] == null
      ? null
      : CountryResponse.fromJson(json['country'] as Map<String, dynamic>)
  ..countryID = json['countryID'] as int?
  ..active = json['active'] as bool?;

Map<String, dynamic> _$CityResponseToJson(CityResponse instance) =>
    <String, dynamic>{
      'id': instance.id,
      'name': instance.name,
      'shortName': instance.shortName,
      'postalCode': instance.postalCode,
      'country': instance.country,
      'countryID': instance.countryID,
      'active': instance.active,
    };
