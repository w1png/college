import sqlite3

conn = sqlite3.connect('denis.db')
c = conn.cursor()

c.execute("""
    CREATE TABLE IF NOT EXISTS users (
        id INTEGER PRIMARY KEY,
        name TEXT,
        surname TEXT,
        balance INTEGER
    )
""")

c.execute("""
    CREATE TABLE IF NOT EXISTS items (
        id INTEGER PRIMARY KEY,
        title TEXT,
        price FLOAT
    )
""")

c.execute("""
    CREATE TABLE IF NOT EXISTS orders (
        id INTEGER PRIMARY KEY,
        user_id INTEGER,
        FOREIGN KEY(user_id) REFERENCES users(id)
        items TEXT,
        total_price FLOAT
    )
""")

conn.commit()

c.execute("""
    ALTER TABLE orders ADD COLUMN status TEXT
""")

c.execute("""
    ALTER TABLE items ADD COLUMN description TEXT
""")

c.execute("""
      ALTER TABLE users ADD COLUMN adress TEXT
""")

conn.commit()

###################
c.execute("""
    INSERT INTO users (name, surname, balance, adress) VALUES
    ('Denis', 'Kuznetsov', 948724, 'Moscow'),
""")

c.execute("""
    INSERT INTO users (name, surname, balance, adress) VALUES
    ('Ivan', 'Ivanov', 666, 'Moscow'),
""")

c.execute("""
    INSERT INTO users (name, surname, balance, adress) VALUES
    ('Petr', 'Petrov', 1337, 'Moscow'),
""")

c.execute("""
    INSERT INTO users (name, surname, balance, adress) VALUES
    ('Sidor', 'Sidorov', 1488, 'Moscow'),
""")

c.execute("""
    INSERT INTO users (name, surname, balance, adress) VALUES
    ('Vasya', 'Vasilev', 228, 'Moscow'),
""")


###################
c.execute("""
    INSERT INTO items (title, price, description) VALUES
    ('Apple', 100, 'Red'),
""")

c.execute("""
    INSERT INTO items (title, price, description) VALUES
    ('Orange', 200, 'Orange'),
""")

c.execute("""
    INSERT INTO items (title, price, description) VALUES
    ('Banana', 300, 'Yellow'),
""")

c.execute("""
    INSERT INTO items (title, price, description) VALUES
    ('Pineapple', 400, 'Yellow'),
""")

c.execute("""
    INSERT INTO items (title, price, description) VALUES
    ('Watermelon', 500, 'Green'),
""")


###################
c.execute("""
    INSERT INTO orders (user_id, items, total_price, status) VALUES
    (1, 'Apple', 100, 0),
""")

c.execute("""
    INSERT INTO orders (user_id, items, total_price, status) VALUES
    (2, 'Orange', 200, -1),
""")

c.execute("""
    INSERT INTO orders (user_id, items, total_price, status) VALUES
    (3, 'Banana', 300, 1),
""")

c.execute("""
    INSERT INTO orders (user_id, items, total_price, status) VALUES
    (4, 'Pineapple', 400, 0),
""")

c.execute("""
    INSERT INTO orders (user_id, items, total_price, status) VALUES
    (4, 'Watermelon', 500, 1),
""")

conn.commit()
conn.close()

# select using union
c.execute("""
    SELECT * FROM users
    UNION
    SELECT * FROM items
    UNION
    SELECT * FROM orders
""")
