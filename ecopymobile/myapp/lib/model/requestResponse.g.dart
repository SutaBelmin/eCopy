// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'requestResponse.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

RequestResponse _$RequestResponseFromJson(Map<String, dynamic> json) =>
    RequestResponse()
      ..id = json['id'] as String?
      ..status = json['status'] as int?
      ..side = json['side'] as int?
      ..options = json['options'] as int?
      ..orientation = json['orientation'] as int?
      ..letter = json['letter'] as int?
      ..collate = json['collate'] as int?
      ..pagePerSheet = json['pagePerSheet'] as int?
      ..price = (json['price'] as num?)?.toDouble();

Map<String, dynamic> _$RequestResponseToJson(RequestResponse instance) =>
    <String, dynamic>{
      'id': instance.id,
      'status': instance.status,
      'side': instance.side,
      'options': instance.options,
      'orientation': instance.orientation,
      'letter': instance.letter,
      'collate': instance.collate,
      'pagePerSheet': instance.pagePerSheet,
      'price': instance.price,
    };
