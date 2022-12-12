// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'zahtjev.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Zahtjev _$ZahtjevFromJson(Map<String, dynamic> json) => Zahtjev()
  ..Id = json['Id'] as int?
  ..status = json['status'] as int?
  ..side = json['side'] as int?
  ..options = json['options'] as int?
  ..orientation = json['orientation'] as int?
  ..letter = json['letter'] as int?
  ..collate = json['collate'] as int?;

Map<String, dynamic> _$ZahtjevToJson(Zahtjev instance) => <String, dynamic>{
      'Id': instance.Id,
      'status': instance.status,
      'side': instance.side,
      'options': instance.options,
      'orientation': instance.orientation,
      'letter': instance.letter,
      'collate': instance.collate,
    };
