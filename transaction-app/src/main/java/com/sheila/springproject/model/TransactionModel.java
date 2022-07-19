package com.sheila.springproject.model;

import java.io.Serializable;
import java.util.UUID;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.EnumType;
import javax.persistence.Enumerated;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

import com.sheila.springproject.enums.DescriptionType;

import lombok.Data;

@Entity
@Table(name = "transactions")
@Data
public class TransactionModel implements Serializable{

	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.AUTO)
	private UUID id;

	@Column
	private String account;

	@Column
	private String description;

	@Column
	@Enumerated(EnumType.STRING)
	private DescriptionType  type;

	@Column
	private Double value;

}
