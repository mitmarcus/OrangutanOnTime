package via.group1.packet_service.persistance.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import via.group1.packet_service.persistance.entity.Packet;

import java.util.ArrayList;
import java.util.Optional;

@Repository
public interface PacketRepository extends JpaRepository<Packet, Long> {
    Optional<Packet> findByTrackingNumber(String trackingNumber);

    Optional<ArrayList<Packet>> findBySenderId(Long senderId);

    Optional<ArrayList<Packet>> findByReceiverId(Long receiverId);
}
