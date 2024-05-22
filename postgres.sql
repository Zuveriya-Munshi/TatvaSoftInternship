-- Create New Table
CREATE TABLE customer (
   customer_id serial PRIMARY KEY,
   first_name character varying(100) NOT NULL,
   last_name character varying(100) NOT NULL,
   email character varying(255) UNIQUE NOT NULL,
   created_date timestamp with time zone NOT NULL DEFAULT now(),
   updated_date timestamp with time zone
);

-- Select Statement
SELECT * from customer

-- Multiple Insert statement
INSERT INTO customer (first_name, last_name, email, created_date, updated_date)
VALUES 
  ('John', 'Doe', 'john.doe@example.com', '2024-05-22 10:00:00', NULL),
  ('Jane', 'Smith', 'jane.smith@example.com', '2024-05-22 11:00:00', NULL),
  ('Alice', 'Johnson', 'alice.johnson@example.com', '2024-05-22 12:00:00', NULL);

-- Update customer 1 first_name
Update customer set first_name = 'Jonny' where customer_id = 1;

-- Drop Table
DROP TABLE IF EXISTS customer;

-- Add New Column
ALTER TABLE customer ADD COLUMN active boolean;

-- Drop New Column
ALTER TABLE customer DROP COLUMN active;

-- After Delete Column - Select Statement
SELECT * from customer


-- Rename Existing Column
ALTER TABLE customer RENAME COLUMN email TO email_address;

-- After Rename Column - Select Statement
SELECT * from customer

ALTER TABLE customer RENAME COLUMN email_address TO email;

-- Rename table name
ALTER TABLE customer RENAME TO users;

ALTER TABLE users RENAME TO customer;

-- Create New Orders Table
CREATE TABLE orders (
    order_id SERIAL PRIMARY KEY,
    customer_id INTEGER NOT NULL REFERENCES customer(customer_id),
    order_date timestamp with time zone NOT NULL DEFAULT now(),
    order_number CHARACTER VARYING(50) NOT NULL,
    order_amount DECIMAL(10,2) NOT NULL
);

-- Inserting new orders
INSERT INTO orders (customer_id, order_date, order_number, order_amount)
VALUES
  (1, '2024-05-22 10:00:00', 'ORD001', 100.00),
  (2, '2024-05-22 11:00:00', 'ORD002', 150.50),
  (1, '2024-05-22 12:00:00', 'ORD003', 200.75);

-- Select order
Select * from orders

-- Delete order of customer_id 1
Delete from orders where customer_id = 2


SELECT * from orders
where customer_id IN (select customer_id from customer where active = true)


SELECT
    customer_id,
	first_name,
	last_name,
	email
FROM
	customer
WHERE
	EXISTS (
		SELECT
			1
		FROM
			orders
		WHERE
			orders.customer_id = customer.customer_id
	);


-- Task 1
Select * from customer order by first_name ASC , last_name DESC

-- Task 2
Select first_name , last_name from customer where first_name LIKE '%oh%'
