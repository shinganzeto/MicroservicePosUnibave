package com.sheila.springproject.repository;
import java.util.UUID;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.sheila.springproject.model.TransactionModel;

@Repository
public interface TransactionRepository extends JpaRepository<TransactionModel, UUID>{

    
}
