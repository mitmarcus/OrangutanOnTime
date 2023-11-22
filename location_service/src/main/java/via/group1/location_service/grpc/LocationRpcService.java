package via.group1.location_service.grpc;

import io.grpc.stub.StreamObserver;
import lombok.RequiredArgsConstructor;
import net.devh.boot.grpc.server.service.GrpcService;
import via.group1.location_service.grpc.generated.LocationServiceGrpc;
import via.group1.location_service.grpc.generated.LocationServiceOuterClass;
import via.group1.location_service.model.interfaces.AddressService;
import via.group1.location_service.model.interfaces.LocationService;
import via.group1.location_service.persistance.entity.Address;
import via.group1.location_service.persistance.entity.Location;

@GrpcService
@RequiredArgsConstructor
public class LocationRpcService extends LocationServiceGrpc.LocationServiceImplBase
{
  private final LocationService locationService;
  private final AddressService addressService;
  private final LocationRpcMapper mapper;

  @Override
  public void getLocationById(LocationServiceOuterClass.getLocationIdRpc request,
                              StreamObserver<LocationServiceOuterClass.Location> responseObserver)
  {
    Location location = locationService.getLocation(request.getId());
    LocationServiceOuterClass.Location locationRpc = mapper.buildLocationRpc(location);
    responseObserver.onNext(locationRpc);
    responseObserver.onCompleted();
  }

  @Override
  public void getAddressById(LocationServiceOuterClass.getAddressIdRpc request,
                              StreamObserver<LocationServiceOuterClass.Address> responseObserver)
  {
    Address address = addressService.getAddress(request.getId());
    LocationServiceOuterClass.Address addressRpc = mapper.buildAddressRpc(address);
    responseObserver.onNext(addressRpc);
    responseObserver.onCompleted();
  }
}
