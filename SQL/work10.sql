SELECT city,country from city LEFT JOIN country ON country.country_id=city.country_id; 

SELECT first_name,last_name,payment_id from customer RIGHT JOIN payment ON payment.customer_id=customer.customer_id;

SELECT first_name,last_name,rental_id from customer FULL JOIN rental ON rental.customer_id=customer.customer_id;