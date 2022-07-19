package com.sheila.springproject.service;

import javax.transaction.Transactional;

import org.springframework.stereotype.Service;

import com.sheila.springproject.model.TransactionModel;
import com.sheila.springproject.repository.TransactionRepository;

@Service
public class TransactionService {

	final TransactionRepository transactionRepository;

	public TransactionService(TransactionRepository transactionRepository) {
		this.transactionRepository = transactionRepository;
	}

    @Transactional
	public TransactionModel save(TransactionModel transactionModel) {
		return transactionRepository.save(transactionModel);
	}

}
