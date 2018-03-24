-- 1. What query would you run to get the total revenue for March of 2012?
SELECT MONTHNAME(charged_datetime) AS month, SUM(amount) AS total_revenue FROM billing
WHERE MONTHNAME(charged_datetime) = 'March' AND YEAR(charged_datetime) = 2012;

-- 2. What query would you run to get total revenue collected from the client with an id of 2?
SELECT clients.client_id, SUM(amount) AS total_revenue 
FROM clients 
LEFT JOIN billing ON clients.client_id = billing.client_id
WHERE clients.client_id = 2;

-- 3. What query would you run to get all the sites that client=10 owns?
SELECT sites.domain_name AS website, sites.client_id FROM sites
WHERE sites.client_id = 10;

-- 4. What query would you run to get total # of sites created per month per year for the client with an id of 1? What about for client=20?
SELECT clients.client_id, COUNT(sites.domain_name) AS number_of_sites, MONTHNAME(sites.created_datetime) AS month_created, YEAR(sites.created_datetime) AS year_created
FROM clients
LEFT JOIN sites on clients.client_id = sites.client_id
WHERE clients.client_id = 1 OR clients.client_id = 20
GROUP BY sites.domain_name
ORDER BY year_created;

-- 5. What query would you run to get the total # of leads generated for each of the sites between January 1, 2011 to February 15, 2011?
SELECT sites.domain_name AS website, COUNT(leads.leads_id) AS leads, leads.registered_datetime AS date_generated-- , COUNT(leads.leads_id) AS number_of_leads
FROM leads
LEFT JOIN sites ON sites.site_id = leads.site_id
WHERE leads.registered_datetime BETWEEN '2011-01-01' AND '2011-02-15'
GROUP BY sites.domain_name;

-- 6. What query would you run to get a list of client names and the total # of leads we've generated for each of our clients between January 1, 2011 to December 31, 2011?
SELECT CONCAT_WS(' ', clients.first_name, clients.last_name) AS client_name, COUNT(leads.leads_id) AS leads
FROM clients
LEFT JOIN sites ON clients.client_id = sites.client_id 
LEFT JOIN leads ON sites.site_id = leads.site_id
WHERE leads.registered_datetime BETWEEN '2011-01-01' AND '11-12-31'
GROUP BY client_name
ORDER BY leads DESC;

-- 7. What query would you run to get a list of client names and the total # of leads we've generated for each client each month between months 1 - 6 of Year 2011?
SELECT CONCAT_WS(' ', clients.first_name, clients.last_name) AS client_name, COUNT(leads.leads_id) AS number_of_leads , MONTHNAME(leads.registered_datetime) AS month_generated
FROM clients
LEFT JOIN sites ON clients.client_id = sites.client_id 
LEFT JOIN leads ON sites.site_id = leads.site_id
WHERE MONTH(leads.registered_datetime) BETWEEN 1 AND 6 AND YEAR(leads.registered_datetime) = 2011
GROUP BY sites.site_id
ORDER BY MONTH(leads.registered_datetime);

-- 8. What query would you run to get a list of client names and the total # of leads we've generated for each of our clients' sites between January 1, 2011 to December 31, 2011? Order this query by client id.  Come up with a second query that shows all the clients, the site name(s), and the total number of leads generated from each site for all time.
SELECT CONCAT_WS(' ', clients.first_name, clients.last_name) AS client_name, sites.domain_name AS website, COUNT(leads.leads_id) AS number_of_leads, leads.registered_datetime AS date_generated
FROM leads
LEFT JOIN sites ON leads.site_id = sites.site_id 
LEFT JOIN clients ON sites.client_id = clients.client_id
WHERE leads.registered_datetime BETWEEN '2011-01-01' AND '2011-12-31'
GROUP BY website
ORDER BY clients.client_id;

SELECT CONCAT_WS(' ', clients.first_name, clients.last_name) AS client_name, sites.domain_name AS website, COUNT(leads.leads_id) AS number_of_leads
FROM leads
LEFT JOIN sites ON leads.site_id = sites.site_id 
LEFT JOIN clients ON sites.client_id = clients.client_id
GROUP BY website
ORDER BY clients.client_id;

-- 9. Write a single query that retrieves total revenue collected from each client for each month of the year. Order it by client id.
SELECT CONCAT_WS(' ', clients.first_name, clients.last_name) AS client_name, SUM(billing.amount) AS total_revenue, MONTHNAME(billing.charged_datetime) AS month_charged, YEAR(billing.charged_datetime) AS year_charged 
FROM billing
LEFT JOIN clients ON billing.client_id = clients.client_id
GROUP BY client_name, MONTH(billing.charged_datetime), YEAR(billing.charged_datetime)
ORDER BY clients.client_id, year_charged, MONTH(billing.charged_datetime);

-- 10. Write a single query that retrieves all the sites that each client owns. Group the results so that each row shows a new client. It will become clearer when you add a new field called 'sites' that has all the sites that the client owns. (HINT: use GROUP_CONCAT
SELECT CONCAT_WS(' ', clients.first_name, clients.last_name) AS client_name, GROUP_CONCAT('/', sites.domain_name)
FROM sites 
LEFT JOIN clients ON sites.client_id = clients.client_id
GROUP BY clients.client_id;

