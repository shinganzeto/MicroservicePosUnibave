package com.sheila.springproject.controller;

import javax.validation.Valid;

import org.springframework.amqp.core.Message;
import org.springframework.amqp.rabbit.core.RabbitTemplate;
import org.springframework.beans.BeanUtils;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.sheila.springproject.dto.TransactionDto;
import com.sheila.springproject.model.TransactionModel;
import com.sheila.springproject.service.TransactionService;


@RestController
@CrossOrigin(origins = "*")
@RequestMapping("/transaction")
public class TransactionController {

    final TransactionService transactionService;
    
    @Autowired
    private RabbitTemplate rabbitTemplate;
    

    public TransactionController(TransactionService transactionService) {
        this.transactionService = transactionService;
    }

    @PostMapping
	public ResponseEntity<Object> saveTransaction(@RequestBody @Valid TransactionDto transactionDto ) {
		var transactionModel = new TransactionModel();
		BeanUtils.copyProperties(transactionDto, transactionModel);
		String rountingKey = "transactions";
		
		Message message = new Message(transactionDto.toString().getBytes());
		
		rabbitTemplate.send(rountingKey, message);
		return ResponseEntity.status(HttpStatus.CREATED).body(transactionService.save(transactionModel));
	}
    


}