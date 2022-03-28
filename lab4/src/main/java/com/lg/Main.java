package com.lg;

import jakarta.persistence.EntityManager;
import jakarta.persistence.EntityManagerFactory;
import jakarta.persistence.Persistence;
import jakarta.persistence.Query;

import com.google.common.io.ByteStreams;
import java.io.IOException;
import java.io.InputStream;
import java.util.List;

public class Main {
    public static void main(String[] args) throws IOException {
        System.out.println("JPA project");
        EntityManagerFactory factory = Persistence.createEntityManagerFactory("Hibernate_JPA");
        EntityManager em = factory.createEntityManager();
        em.getTransaction().begin();

        // 4.3.1
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

        // 4.3.2
        User u1 = em.find(User.class, 1);
        u1.setPassword("new_password");
        em.merge(u1);

        // 4.3.3
        Role r1 = em.find(Role.class, 5);
        em.remove(r1);

        // 4.3.4
        Query query = em.createQuery("SELECT u FROM User u WHERE u.lastName = 'Kowalski'");
        List<User> queryRes = query.getResultList();
        System.out.println("Users: ");
        for (User res : queryRes)
            System.out.println("\t" + res.toString());

        // 4.3.5
        query = em.createQuery("SELECT u FROM User u WHERE u.sex = 'FEMALE'");
        queryRes = query.getResultList();
        System.out.println("\nFemales: ");
        for (User res : queryRes)
            System.out.println("\t" + res.toString());


        // 4.4.4
        User u2 = new User(null, "test_5", "test_5", "Andrzej", "Kowalski", Sex.MALE);
        u2.addRole(em.find(Role.class, 1L));
        u2.addRole(em.find(Role.class, 3L));
        em.persist(u2);

        // 4.4.5
        UsersGroup g1 = new UsersGroup();
        g1.addUser(u1);
        g1.addUser(u2);
        em.persist(g1);

        UsersGroup g2 = new UsersGroup();
        g2.addUser(u1);
        em.persist(g2);

        // 4.5.2
        InputStream inputStream = Main.class.getResourceAsStream("/doggo.jpeg");
        assert inputStream != null;
        byte[] img = ByteStreams.toByteArray(inputStream);

        var u = new User(null, "blob_user", "password", "name", "lastname", Sex.MALE);
        u.setImg(img);
        em.persist(u);

        em.getTransaction().commit();
        em.close();
        factory.close();
    }
}
