// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'passRequest.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

PassRequest _$PassRequestFromJson(Map<String, dynamic> json) => PassRequest()
  ..oldPass = json['oldPass'] as String?
  ..newPass = json['newPass'] as String?
  ..confPass = json['confPass'] as String?;

Map<String, dynamic> _$PassRequestToJson(PassRequest instance) =>
    <String, dynamic>{
      'oldPass': instance.oldPass,
      'newPass': instance.newPass,
      'confPass': instance.confPass,
    };
