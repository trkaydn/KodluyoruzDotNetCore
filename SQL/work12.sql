SELECT COUNT(*) FROM film WHERE length > (SELECT AVG(length) from film);

SELECT COUNT(*) FROM film WHERE rental_rate = (SELECT MAX(rental_rate) from film);

SELECT * FROM film WHERE rental_rate = (SELECT MIN(rental_rate) from film) AND replacement_cost =(SELECT  MIN(replacement_cost) from film);

SELECT first_name, last_name, (SELECT COUNT(*) FROM payment WHERE payment.customer_id = customer.customer_id) AS payment_count FROM customer ORDER BY payment_count DESC;