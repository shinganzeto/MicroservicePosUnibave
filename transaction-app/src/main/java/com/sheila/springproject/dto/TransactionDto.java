package com.sheila.springproject.dto;

import com.sheila.springproject.enums.DescriptionType;

import lombok.Data;

@Data
public class TransactionDto {

	private String account;

	private String description;

	private DescriptionType type;

	private Double value;


}