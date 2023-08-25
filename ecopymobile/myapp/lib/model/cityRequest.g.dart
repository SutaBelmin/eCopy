// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'cityRequest.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

CityRequest _$CityRequestFromJson(Map<String, dynamic> json) => CityRequest()
  ..name = json['name'] as String?
  ..shortName = json['shortName'] as String?
  ..postalCode = json['postalCode'] as int?
  ..countryID = json['countryID'] as int?
  ..active = json['active'] as bool?;

Map<String, dynamic> _$CityRequestToJson(CityRequest instance) =>
    <String, dynamic>{
      'name': instance.name,
      'shortName': instance.shortName,
      'postalCode': instance.postalCode,
      'countryID': instance.countryID,
      'active': instance.active,
    };
