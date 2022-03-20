package com.lg;

import jakarta.persistence.EntityManager;
import jakarta.persistence.EntityManagerFactory;
import jakarta.persistence.Persistence;
import jakarta.persistence.Query;

import java.util.List;

public class Main {
    public static void main(String[] args) {
        System.out.println("JPA project");
        EntityManagerFactory factory = Persistence.createEntityManagerFactory("Hibernate_JPA");
        EntityManager em = factory.createEntityManager();
        em.getTransaction().begin();

        em.persist(new User(null, "test_1", "test_1", "Andrzej", "Kowalski", Sex.MALE));
        em.persist(new User(null, "test_2", "test_2", "Andrzej", "Kowalski", Sex.FEMALE));
        em.persist(new User(null, "test_3", "test_3", "Andrzej", "Kowalski", Sex.MALE));
        em.persist(new User(null, "test_4", "test_4", "Andrzej", "Kowalski", Sex.FEMALE));
        em.persist(new User(null, "test_5", "test_5", "Andrzej", "Kowalski", Sex.MALE));

        em.persist(new Role(null, "role_1"));
        em.persist(new Role(null, "role_2"));
        em.persist(new Role(null, "role_3"));
        em.persist(new Role(null, "role_4"));
        em.persist(new Role(null, "role_5"));

        User u1 = em.find(User.class, 1);
        u1.setPassword("new_password");
        em.merge(u1);

        Role r1 = em.find(Role.class, 5);
        em.remove(r1);

        Query query = em.createQuery("SELECT u FROM User u WHERE u.lastName = 'Kowalski'");
        List<User> queryRes = query.getResultList();
        System.out.println("Users: ");
        for (User res : queryRes)
            System.out.println("\t" + res.toString());

        query = em.createQuery("SELECT u FROM User u WHERE u.sex = 'FEMALE'");
        queryRes = query.getResultList();
        System.out.println("\nFemales: ");
        for (User res : queryRes)
            System.out.println("\t" + res.toString());

        User u2 = new User(null, "test_5", "test_5", "Andrzej", "Kowalski", Sex.MALE);
        u2.addRole(em.find(Role.class, 1L));
        u2.addRole(em.find(Role.class, 3L));
        em.persist(u2);

        UsersGroup g1 = new UsersGroup();
        g1.addUser(u1);
        g1.addUser(u2);
        em.persist(g1);

        UsersGroup g2 = new UsersGroup();
        g2.addUser(u1);
        em.persist(g2);

        em.getTransaction().commit();
        em.close();
        factory.close();
    }
}
