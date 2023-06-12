// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'printRequest.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

PrintRequest _$PrintRequestFromJson(Map<String, dynamic> json) => PrintRequest()
  ..id = json['id'] as String?
  ..status = json['status'] as int?
  ..side = json['side'] as int?
  ..options = json['options'] as int?
  ..orientation = json['orientation'] as int?
  ..letter = json['letter'] as int?
  ..collate = json['collate'] as int?
  ..pagePerSheet = json['pagePerSheet'] as int?
  ..price = (json['price'] as num?)?.toDouble()
  ..isPaid = json['isPaid'] as bool?;

Map<String, dynamic> _$PrintRequestToJson(PrintRequest instance) =>
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
      'isPaid': instance.isPaid,
    };
